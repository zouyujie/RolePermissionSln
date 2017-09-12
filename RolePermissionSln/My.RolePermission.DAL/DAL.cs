using My.RolePermission.Model;
using My.RolePermission.IDAL;

namespace My.RolePermission.DAL
{
	public partial class SMFIELDRepository : BaseRepository<SMFIELD>,ISMFIELDRepository
    {
    }
	public partial class SMFUNCTBRepository : BaseRepository<SMFUNCTB>,ISMFUNCTBRepository
    {
    }
	public partial class SMLOGRepository : BaseRepository<SMLOG>,ISMLOGRepository
    {
    }
	public partial class SMMENUROLEFUNCTBRepository : BaseRepository<SMMENUROLEFUNCTB>,ISMMENUROLEFUNCTBRepository
    {
    }
	public partial class SMMENUTBRepository : BaseRepository<SMMENUTB>,ISMMENUTBRepository
    {
    }
	public partial class SMROLETBRepository : BaseRepository<SMROLETB>,ISMROLETBRepository
    {
    }
	public partial class SMUSERTBRepository : BaseRepository<SMUSERTB>,ISMUSERTBRepository
    {
    }
}