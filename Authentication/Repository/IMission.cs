using Authentication.Entities;
using Authentication.Model;

namespace Authentication.Repository
{
    public interface IMission
    {
        Task<List<MissionViewModel>> GetMissionsWithDetails();
        Task<string> CreateMission(MissionDto model);
        Task<MissionViewModel> GetMissionDetailsById(int missionId);
        Task<string> UpdateMission(int missionId, MissionDto model);

        Task<string> DeleteMission(int id);
    }
}
