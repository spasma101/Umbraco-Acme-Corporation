using Acme_Corporation_Core.App_Code.Helpers;
using Acme_Corporation_Core.App_Code.Models;

namespace Acme_Corporation_Core.App_Code.Repository
{
	public class CompetitionFormRepository : Repository<CompetitionSubmit>
	{
		private string umbracoDbDSN;

		public CompetitionFormRepository()
			: this(AppSettings.umbracoDbDSN)
		{
		}

		public CompetitionFormRepository(string connectionString) : base(connectionString)
		{
		}
	}
}