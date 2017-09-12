using My.RolePermission.DAL;
using My.RolePermission.IDAL;

namespace My.RolePermission.DALSessionFactory
{
	public partial class DBSession : IDBSession
    {
	
		private ISMFIELDRepository _SMFIELDRepository;
        public ISMFIELDRepository ISMFIELDRepository
        {
            get
            {
                if(_SMFIELDRepository == null)
                {
                   // _SMFIELDRepository = new SMFIELDRepository();
				    _SMFIELDRepository =DalFactory.GetSMFIELDRepository;
                }
                return _SMFIELDRepository;
            }
            set { _SMFIELDRepository = value; }
        }
	
		private ISMFUNCTBRepository _SMFUNCTBRepository;
        public ISMFUNCTBRepository ISMFUNCTBRepository
        {
            get
            {
                if(_SMFUNCTBRepository == null)
                {
                   // _SMFUNCTBRepository = new SMFUNCTBRepository();
				    _SMFUNCTBRepository =DalFactory.GetSMFUNCTBRepository;
                }
                return _SMFUNCTBRepository;
            }
            set { _SMFUNCTBRepository = value; }
        }
	
		private ISMLOGRepository _SMLOGRepository;
        public ISMLOGRepository ISMLOGRepository
        {
            get
            {
                if(_SMLOGRepository == null)
                {
                   // _SMLOGRepository = new SMLOGRepository();
				    _SMLOGRepository =DalFactory.GetSMLOGRepository;
                }
                return _SMLOGRepository;
            }
            set { _SMLOGRepository = value; }
        }
	
		private ISMMENUROLEFUNCTBRepository _SMMENUROLEFUNCTBRepository;
        public ISMMENUROLEFUNCTBRepository ISMMENUROLEFUNCTBRepository
        {
            get
            {
                if(_SMMENUROLEFUNCTBRepository == null)
                {
                   // _SMMENUROLEFUNCTBRepository = new SMMENUROLEFUNCTBRepository();
				    _SMMENUROLEFUNCTBRepository =DalFactory.GetSMMENUROLEFUNCTBRepository;
                }
                return _SMMENUROLEFUNCTBRepository;
            }
            set { _SMMENUROLEFUNCTBRepository = value; }
        }
	
		private ISMMENUTBRepository _SMMENUTBRepository;
        public ISMMENUTBRepository ISMMENUTBRepository
        {
            get
            {
                if(_SMMENUTBRepository == null)
                {
                   // _SMMENUTBRepository = new SMMENUTBRepository();
				    _SMMENUTBRepository =DalFactory.GetSMMENUTBRepository;
                }
                return _SMMENUTBRepository;
            }
            set { _SMMENUTBRepository = value; }
        }
	
		private ISMROLETBRepository _SMROLETBRepository;
        public ISMROLETBRepository ISMROLETBRepository
        {
            get
            {
                if(_SMROLETBRepository == null)
                {
                   // _SMROLETBRepository = new SMROLETBRepository();
				    _SMROLETBRepository =DalFactory.GetSMROLETBRepository;
                }
                return _SMROLETBRepository;
            }
            set { _SMROLETBRepository = value; }
        }
	
		private ISMUSERTBRepository _SMUSERTBRepository;
        public ISMUSERTBRepository ISMUSERTBRepository
        {
            get
            {
                if(_SMUSERTBRepository == null)
                {
                   // _SMUSERTBRepository = new SMUSERTBRepository();
				    _SMUSERTBRepository =DalFactory.GetSMUSERTBRepository;
                }
                return _SMUSERTBRepository;
            }
            set { _SMUSERTBRepository = value; }
        }
	}	
}