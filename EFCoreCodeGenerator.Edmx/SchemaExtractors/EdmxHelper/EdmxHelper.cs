// http://www.codeproject.com/KB/library/EdmxParsing.aspx

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using EFCoreCodeGenerator.SchemaExtractors.EdmxHelper.DataObjects;
using EFCoreCodeGenerator.SchemaExtractors.EdmxHelper.SortComparison;
using EdmxComplexType = System.Data.Metadata.Edm.ComplexType;
using EdmxEdmItemCollection = System.Data.Metadata.Edm.EdmItemCollection;
using EdmxEdmMember = System.Data.Metadata.Edm.EdmMember;
using EdmxEdmProperty = System.Data.Metadata.Edm.EdmProperty;
using EdmxEdmType = System.Data.Metadata.Edm.EdmType;
using EdmxEntityContainer = System.Data.Metadata.Edm.EntityContainer;
using EdmxEntitySet = System.Data.Metadata.Edm.EntitySet;
using EdmxEntityType = System.Data.Metadata.Edm.EntityType;
using EdmxFacet = System.Data.Metadata.Edm.Facet;
using EdmxNavigationProperty = System.Data.Metadata.Edm.NavigationProperty;
using EdmxRefType = System.Data.Metadata.Edm.RefType;

namespace EFCoreCodeGenerator.SchemaExtractors.EdmxHelper
{
	public class EdmxHelper
	{
        // XML Information
		
        public static readonly string ConceptualModels = "ConceptualModels";

        // Model Data Members - Public
        public List<Container> Containers { get; private set; }

        // Model Data Members - Private
        private string _filename;
        private Container _currentContainer;
        private bool _isParsed;

        // Entity Framework
        private ObjectContext _context;
        private EdmxEdmItemCollection _metadata;
        private EdmxEntityContainer _edmxContainer;
        private ReadOnlyCollection<EdmxComplexType> _edmxComplexTypes;

        private EdmxHelper()
        {
        }

	    /// <summary>
        /// 
        /// </summary>
        private void Parse()
        {
            if (_isParsed)
                return;

            _metadata = (_context == null)
                ? ReadCsdlCollection(_filename)
                : ReadCsdlCollection(_context);

            _edmxComplexTypes = _metadata.GetItems<EdmxComplexType>();

            foreach (EdmxEntityContainer edmxContainer in _metadata.GetItems<EdmxEntityContainer>())
            {
                _edmxContainer = edmxContainer;

                _currentContainer = new Container { Name = edmxContainer.Name };
                Containers.Add(_currentContainer);

                CreateEntitySets();
                CreateAssociationSets();
            }

            Containers.Sort(new SortContainer());

            _isParsed = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void CreateEntitySets()
        {
            IEnumerable<EdmxEntitySet> entitySets = _edmxContainer.BaseEntitySets.OfType<EdmxEntitySet>();
            foreach (EdmxEntitySet edmxEntitySet in entitySets)
                _currentContainer.Entities.Add(CreateEntityType(edmxEntitySet.ElementType, edmxEntitySet.Name));

            _currentContainer.Entities.Sort(new SortEntities());
        }

        /// <summary>
        /// ForeignKey를 설정한다.
        /// </summary>
        private void CreateAssociationSets()
        {
            foreach (AssociationSet set in _edmxContainer.BaseEntitySets.OfType<AssociationSet>())
            {
                if (set.ElementType.ReferentialConstraints.Count == 0)
                    continue;

                var constraint = set.ElementType.ReferentialConstraints[0];

                if (constraint == null)
                    continue;

                var entity = _currentContainer.Entities.Find(x => x.Name == constraint.ToRole.Name);
                if (entity == null)
                    continue;

                var property = entity.Scalars.Find(x => x.Name == constraint.ToProperties[0].Name);
                if (property == null)
                    continue;

                property.ForeignKey = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edmxEdmType"></param>
        private void CreateComplexType(EdmxEdmType edmxEdmType)
        {
            if (_currentContainer.Structures.Find(s => s.Name.Equals(edmxEdmType.Name)
                && s.Namespace.Equals(edmxEdmType.NamespaceName)) != null)
            {
                // already created it
                return;
            }

            EdmxComplexType edmxComplexType = _edmxComplexTypes.SingleOrDefault(c => c.FullName.Equals(edmxEdmType.FullName));
            if (edmxComplexType == null)
                throw new TypeLoadException(edmxEdmType.FullName + " was not found.");

            Entity entity = new Entity
            {
                Name = edmxComplexType.Name,
                Namespace = edmxComplexType.NamespaceName,
                BaseName = (edmxComplexType.BaseType == null) ? null : edmxComplexType.BaseType.Name,
                BaseNamespace = (edmxComplexType.BaseType == null) ? null : edmxComplexType.BaseType.NamespaceName,
                IsAbstract = edmxComplexType.Abstract
            };

            foreach (EdmxEdmProperty edmxEdmProperty in edmxComplexType.Properties.Where(c => c.DeclaringType == edmxComplexType))
                CreateScalarProperty(null, entity, edmxEdmProperty);

            _currentContainer.Structures.Add(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edmxEntityType"></param>
        /// <param name="setName"></param>
        /// <returns></returns>
        private Entity CreateEntityType(EdmxEntityType edmxEntityType, string setName)
        {
            Entity entity = new Entity
            {
                SetName = setName,
                Name = edmxEntityType.Name,
                Namespace = edmxEntityType.NamespaceName,
                BaseName = (edmxEntityType.BaseType == null) ? null : edmxEntityType.BaseType.Name,
                BaseNamespace = (edmxEntityType.BaseType == null) ? null : edmxEntityType.BaseType.NamespaceName,
                IsAbstract = edmxEntityType.Abstract
            };

            CreateScalarProperties(edmxEntityType, entity);
            CreateNavigationProperties(edmxEntityType, entity);

            entity.Keys.Sort(new SortScalars());
            entity.Scalars.Sort(new SortScalars());
            entity.SingleReferences.Sort(new SortReferences());
            entity.MultipleReferences.Sort(new SortReferences());

            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edmxEntityType"></param>
        /// <param name="entity"></param>
        private void CreateScalarProperties(EdmxEntityType edmxEntityType, Entity entity)
        {
            foreach (EdmxEdmProperty edmxEdmProperty in edmxEntityType.Properties.Where(c => c.DeclaringType == edmxEntityType))
                CreateScalarProperty(edmxEntityType.KeyMembers, entity, edmxEdmProperty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edmxKeyMembers"></param>
        /// <param name="entity"></param>
        /// <param name="edmxEdmProperty"></param>
        private void CreateScalarProperty(ICollection<EdmxEdmMember> edmxKeyMembers, Entity entity, EdmxEdmProperty edmxEdmProperty)
        {
            Scalar property = new Scalar
            {
                Name = edmxEdmProperty.Name,
                IsKey = (edmxKeyMembers != null) && edmxKeyMembers.Contains(edmxEdmProperty),
                DefaultValue = edmxEdmProperty.DefaultValue,
                ScalarType = GetPocoClrType(edmxEdmProperty)
            };

            SetConstraints(property, edmxEdmProperty);

            if (property.IsKey)
                entity.Keys.Add(property);
            else
                entity.Scalars.Add(property);

            if (!IsPrimitiveType(edmxEdmProperty))
                CreateComplexType(edmxEdmProperty.TypeUsage.EdmType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="edmxEdmMember"></param>
        private static void SetConstraints(Scalar property, EdmxEdmMember edmxEdmMember)
        {
            property.Identity = edmxEdmMember.MetadataProperties.Any(x => x.Value.ToString() == "Identity");

            foreach (EdmxFacet facet in edmxEdmMember.TypeUsage.Facets)
            {
                switch (facet.Name)
                {
                    case "DefaultValue":
                    case "FixedLength":
                    case "StoreGeneratedPattern":
                    case "Unicode":
                        break;

                    case "Nullable":
                        property.Nullable = facet.Value is bool && (bool) facet.Value;
                        break;

                    case "MaxLength": property.MaxLength = (facet.Value is int) ? (int?)facet.Value : null; break;
                    case "Precision": property.Precision = (facet.Value is byte) ? (byte?)facet.Value : null; break;
                    case "Scale": property.Scale = (facet.Value is byte) ? (byte?)facet.Value : null; break;
                    default: property.Facets.Add(facet.Name, facet.Value); break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edmxEntityType"></param>
        /// <param name="entity"></param>
        private static void CreateNavigationProperties(EdmxEntityType edmxEntityType, Entity entity)
        {
            foreach (EdmxNavigationProperty edmxNavigationProperty in edmxEntityType.NavigationProperties.Where(c => c.DeclaringType == edmxEntityType))
            {
                EdmxRefType srcDataType = ((EdmxRefType)edmxNavigationProperty.FromEndMember.TypeUsage.EdmType);
                EdmxRefType dstDataType = ((EdmxRefType)edmxNavigationProperty.ToEndMember.TypeUsage.EdmType);

                Reference reference = new Reference
                {
                    Name = edmxNavigationProperty.Name,
                    ReferenceType = new DataType
                    {
                        IsNullable = false,
                        Name = dstDataType.ElementType.Name,
                        Namespace = dstDataType.ElementType.NamespaceName
                    },
                    NavigationType = new NavigationDataType
                    {
                        IsAbstract = edmxNavigationProperty.RelationshipType.Abstract,
                        Name = edmxNavigationProperty.RelationshipType.Name,
                        Namespace = edmxNavigationProperty.RelationshipType.NamespaceName
                    },
                    SrcDataType = new ReferenceDataType
                    {
                        EntityName = srcDataType.ElementType.Name,
                        EntityNamespace = srcDataType.ElementType.NamespaceName,
                        TableName = edmxNavigationProperty.FromEndMember.Name,
                        Multiplicity = Convert(edmxNavigationProperty.FromEndMember.RelationshipMultiplicity)
                    },
                    DstDataType = new ReferenceDataType
                    {
                        EntityName = dstDataType.ElementType.Name,
                        EntityNamespace = dstDataType.ElementType.NamespaceName,
                        TableName = edmxNavigationProperty.ToEndMember.Name,
                        Multiplicity = Convert(edmxNavigationProperty.ToEndMember.RelationshipMultiplicity)
                    }
                };

                if (reference.DstDataType.Multiplicity == Multiplicity.Many)
                    entity.MultipleReferences.Add(reference);
                else
                    entity.SingleReferences.Add(reference);
            }
        }

        public static List<Container> Parse(string filename)
        {
            EdmxHelper helper = new EdmxHelper
            {
                _filename = filename,
                _isParsed = false,
                Containers = new List<Container>()
            };

            helper.Parse();

            return helper.Containers;
        }

        public static List<Container> Parse(ObjectContext context)
        {
            EdmxHelper helper = new EdmxHelper
            {
                _context = context,
                _isParsed = false,
                Containers = new List<Container>()
            };

            helper.Parse();

            return helper.Containers;
        }

        public static EdmItemCollection ReadCsdlCollection(ObjectContext context)
        {
            ItemCollection conceptual;

            MetadataWorkspace mdw = ((EntityConnection)context.Connection).GetMetadataWorkspace();
            mdw.TryGetItemCollection(DataSpace.CSpace, out conceptual);

            return conceptual as EdmItemCollection;
        }

	    /// <summary>
		/// 
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
        public static EdmItemCollection ReadCsdlCollection(string filename)
		{
            using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
//                XElement edmx = XElement.Load(filename);
                XElement edmx = XElement.Load(stream);
                var edmxNamespace = edmx.GetNamespaceOfPrefix("edmx");
                // http://schemas.microsoft.com/ado/2009/11/edmx
                var csdlNodes = edmx.Descendants(edmxNamespace + ConceptualModels).First().Elements();
                var readers = csdlNodes.Select(c => c.CreateReader());

                stream.Close();

                return new EdmItemCollection(readers);
            }
		}

	    /// <summary>
		/// 
		/// </summary>
		/// <param name="prop"></param>
		/// <returns></returns>
		public static bool IsPrimitiveType(EdmProperty prop)
		{
			return (prop.TypeUsage.EdmType is PrimitiveType);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="prop"></param>
		/// <returns></returns>
		public static DataType GetPocoClrType(EdmProperty prop)
		{
			EdmType edmType = prop.TypeUsage.EdmType;

			PrimitiveType pt = edmType as PrimitiveType;
			if (pt != null)
			{
				return new DataType
				{
					IsNullable = prop.Nullable,
					Name = pt.ClrEquivalentType.Name,
					Namespace = pt.ClrEquivalentType.Namespace
				};
			}

			Debug.Assert(edmType is StructuralType);
            
			return new DataType
			{
				IsNullable = false,
				Name = edmType.Name,
				Namespace = edmType.NamespaceName
			};
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="multiplicity"></param>
		/// <returns></returns>
		public static Multiplicity Convert(RelationshipMultiplicity multiplicity)
		{
			switch (multiplicity)
			{
				case RelationshipMultiplicity.ZeroOrOne:	return Multiplicity.ZeroOrOne;
				case RelationshipMultiplicity.One:			return Multiplicity.One;
				case RelationshipMultiplicity.Many:			return Multiplicity.Many;
				default: throw new ArgumentOutOfRangeException("multiplicity", multiplicity.ToString());
			}
		}
	}
}
