using System.ComponentModel.DataAnnotations;

namespace GameServer.Domain.Entity
{
    public class Server
    {
        [Key]
        public Guid ServerId { get; set; }
        public string UniqAddress { get; set; } = string.Empty;
        public string HashGameSession { get; set; }= string.Empty;
        public int MaxPlayers { get; set; }
        public int CurrentPlayers { get; set; }
        public string Region { get; set; } = string.Empty;
        public bool Develop { get; set; }
        public string Name { get; set; } = string.Empty;
        public string GameMode { get; set; } = string.Empty;
        public string MapName { get; set; } = string.Empty;
        public uint Lifetime { get; set; }
        public string Status { get; set; } = string.Empty;
        public string VerifyKey { get; set; } = string.Empty;
    }
}
