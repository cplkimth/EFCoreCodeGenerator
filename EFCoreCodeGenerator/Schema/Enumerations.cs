namespace EFCoreCodeGenerator.Schema
{
    public enum LoopType
    {
        /// <summary>
        /// All
        /// </summary>
        AL,

        /// <summary>
        /// Table
        /// </summary>
        TB,

        /// <summary>
        /// View
        /// </summary>
        VW,

        /// <summary>
        /// Primary Key
        /// </summary>
        PK,

        /// <summary>
        /// Non Primary Key
        /// </summary>
        NP,

        /// <summary>
        /// Foreign Key
        /// </summary>
        FK,

        /// <summary>
        /// Foreign Key
        /// </summary>
        NF,

        /// <summary>
        /// Increament
        /// </summary>
        IN,

        /// <summary>
        /// Non Increament
        /// </summary>
        NI,
    }

    public enum TableType
    {
        Table,
        View
    }
}