using PhoneBook.Business.Abstract;
using PhoneBook.Core.Utilities.Results;
using PhoneBook.DataAccess.Abstract;
using PhoneBook.Entities.Concrete;

namespace PhoneBook.Business.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IReportDal _reportDal;

        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }

        public Report Add(Report report)
        {
            return _reportDal.CustomAdd(report);
        }

        public IDataResult<IList<Report>> GetAll()
        {
            var report = _reportDal.GetList();
            return new SuccessDataResult<IList<Report>>(report, "Raporlar listelendi");
        }

        public IDataResult<Report> GetById(int reportId)
        {
            var report = _reportDal.Get(x => x.UUID == reportId);
            return new SuccessDataResult<Report>(report, "Raporlar listelendi");
        }

        public IResult Update(Report report)
        {
            _reportDal.Update(report);
            return new SuccessResult("Rapor güncellendi");
        }
    }
}