using Authentication.Entities;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Repository
{
    public class MissionTheme:IMissionTheme
    {
        private readonly AuthContext _authContext;
        public MissionTheme(AuthContext authContext)
        {
            _authContext = authContext;
        }

        public async Task<List<Themess>> GetMissionThemes()
        {
            return await _authContext.Themess.ToListAsync();
        }

        public async Task<string> CreateMissionTheme(Themess model)
        {
            await _authContext.Themess.AddAsync(model);
            await _authContext.SaveChangesAsync();
            return "Mission theme created successfully.";
        }

        public async Task<string> UpdateMissionTheme(int missionThemeId, Themess model)
        {
            var existingTheme = await _authContext.Themess.FindAsync(missionThemeId);
            if (existingTheme == null)
            {
                return "Mission theme not found.";
            }

            existingTheme.ThemeName = model.ThemeName;
            existingTheme.ThemeDescription = model.ThemeDescription;
            existingTheme.ThemeImage = model.ThemeImage;

            _authContext.Themess.Update(existingTheme);
            await _authContext.SaveChangesAsync();
            return "Mission theme updated successfully.";
        }

        public async Task<Themess> GetMissionThemeById(int missionThemeId)
        {
            return await _authContext.Themess.FindAsync(missionThemeId);
        }

        public async Task<string> DeleteMissionTheme(int id)
        {
            var theme = await _authContext.Themess.FindAsync(id);
            if (theme == null)
            {
                return "Mission theme not found.";
            }

            _authContext.Themess.Remove(theme);
            await _authContext.SaveChangesAsync();
            return "Mission theme deleted successfully.";
        }
    }
}
