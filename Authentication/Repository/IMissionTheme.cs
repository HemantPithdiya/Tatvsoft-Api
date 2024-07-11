using Authentication.Entities;

namespace Authentication.Repository
{
    public interface IMissionTheme
    {
        Task<List<Themess>> GetMissionThemes();
        Task<string> CreateMissionTheme(Themess model);
        Task<string> UpdateMissionTheme(int missionThemeId, Themess model);
        Task<Themess> GetMissionThemeById(int missionThemeId);
        Task<string> DeleteMissionTheme(int id);
    }
}
