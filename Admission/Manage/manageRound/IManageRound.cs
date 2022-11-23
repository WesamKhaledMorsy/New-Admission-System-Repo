namespace Admission.Manage.manageRound
{
    public interface IManageRound
    {
        void CreateNewRound(RoundDTO round);
        void DeleteRound(Guid id);
        void EditRound(RoundDTO round);
        List<RoundDTO> GetAllRounds(Guid? id, string? name, DateTime? startDate,
            DateTime? endDate, DateTime? startAdmission, DateTime? endAdmission,Guid? adminId, int pageIndex, int pageSize);
        List<RoundDTO> GetRoundById(Guid id);
        List<RoundDTO> GetRounds();
    }
}
