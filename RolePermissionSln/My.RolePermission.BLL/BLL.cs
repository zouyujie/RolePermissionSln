using My.RolePermission.IBLL;
using My.RolePermission.Model;

namespace My.RolePermission.BLL
{
	public partial class SMFIELDService :BaseService<SMFIELD>,ISMFIELDService
    {
        public override void SetCurretnRepository()
        {
            CurrentRepository = this.GetCurrentDbSession.ISMFIELDRepository;
        }
    }   
	public partial class SMFUNCTBService :BaseService<SMFUNCTB>,ISMFUNCTBService
    {
        public override void SetCurretnRepository()
        {
            CurrentRepository = this.GetCurrentDbSession.ISMFUNCTBRepository;
        }
    }   
	public partial class SMLOGService :BaseService<SMLOG>,ISMLOGService
    {
        public override void SetCurretnRepository()
        {
            CurrentRepository = this.GetCurrentDbSession.ISMLOGRepository;
        }
    }   
	public partial class SMMENUROLEFUNCTBService :BaseService<SMMENUROLEFUNCTB>,ISMMENUROLEFUNCTBService
    {
        public override void SetCurretnRepository()
        {
            CurrentRepository = this.GetCurrentDbSession.ISMMENUROLEFUNCTBRepository;
        }
    }   
	public partial class SMMENUTBService :BaseService<SMMENUTB>,ISMMENUTBService
    {
        public override void SetCurretnRepository()
        {
            CurrentRepository = this.GetCurrentDbSession.ISMMENUTBRepository;
        }
    }   
	public partial class SMROLETBService :BaseService<SMROLETB>,ISMROLETBService
    {
        public override void SetCurretnRepository()
        {
            CurrentRepository = this.GetCurrentDbSession.ISMROLETBRepository;
        }
    }   
	public partial class SMUSERTBService :BaseService<SMUSERTB>,ISMUSERTBService
    {
        public override void SetCurretnRepository()
        {
            CurrentRepository = this.GetCurrentDbSession.ISMUSERTBRepository;
        }
    }   
	
}