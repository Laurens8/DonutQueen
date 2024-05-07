using Microsoft.AspNetCore.Mvc.Rendering;

namespace DonutQueen.ViewModels
{
    public class GrantPermissionViewModel
    {
        public SelectList Gebruikers { get; set; }
        public SelectList Rollen { get; set; }
        public string GebruikerId { get; set; }
        public string RolId { get; set; }
    }
}
