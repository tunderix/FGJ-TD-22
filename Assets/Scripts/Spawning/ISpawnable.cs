namespace Creator.Spawning
{
    /// <summary>
    /// Interface for spawnable
    /// </summary>
    public interface ISpawnable
    {
        /// <summary>
        /// Accessor for SpawnableData
        /// </summary>
        /// <returns>Information about spawnable</returns>
        public SpawnableData GetSpawnableData();
        /// <summary>
        /// Accessor for spawnable
        /// </summary>
        /// <returns>Spawnable</returns>
        public Spawnable GetSpawnable();
    }
}
