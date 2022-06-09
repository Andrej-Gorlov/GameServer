using System.ComponentModel.DataAnnotations;

namespace GameServer.Domain.Entity.Dto
{
    public class ServerDto
    {
        public Guid ServerId { get; set; }

        [RegularExpression("^[0-9.:]+$", ErrorMessage = "Недопустимый ввод значений.")]
        public string UniqAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите хеш игровой сессии.")]
        public string HashGameSession { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите максимальное количество игроков.")]
        public int MaxPlayers { get; set; }

        [Required(ErrorMessage = "Укажите количество действующих игроков.")]
        public int CurrentPlayers { get; set; }

        [Required(ErrorMessage = "Укажите регион.")]
        public string Region { get; set; } = string.Empty;

        public bool Develop { get; set; }

        [Required(ErrorMessage = "Укажите название сервера.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите режим игры.")]
        public string GameMode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите название карты.")]
        public string MapName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите время жизни сервера.")]
        public uint Lifetime { get; set; }

        [Required(ErrorMessage = "Укажите статус сервера.")]
        public string Status { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите верифицирующий ключ.")]
        public string VerifyKey { get; set; } = string.Empty;
    }
}
