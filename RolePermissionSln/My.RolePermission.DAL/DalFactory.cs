using My.RolePermission.IDAL;
using My.RolePermission.Ioc;

namespace My.RolePermission.DAL
{
  public partial class DalFactory
  {
	 public static ISMFIELDRepository GetSMFIELDRepository
	 {
	   get
	    {
	     return SpringHelper.GetObject<ISMFIELDRepository>("SMFIELDRepository");
	    }
	 }
  	 public static ISMFUNCTBRepository GetSMFUNCTBRepository
	 {
	   get
	    {
	     return SpringHelper.GetObject<ISMFUNCTBRepository>("SMFUNCTBRepository");
	    }
	 }
  	 public static ISMLOGRepository GetSMLOGRepository
	 {
	   get
	    {
	     return SpringHelper.GetObject<ISMLOGRepository>("SMLOGRepository");
	    }
	 }
  	 public static ISMMENUROLEFUNCTBRepository GetSMMENUROLEFUNCTBRepository
	 {
	   get
	    {
	     return SpringHelper.GetObject<ISMMENUROLEFUNCTBRepository>("SMMENUROLEFUNCTBRepository");
	    }
	 }
  	 public static ISMMENUTBRepository GetSMMENUTBRepository
	 {
	   get
	    {
	     return SpringHelper.GetObject<ISMMENUTBRepository>("SMMENUTBRepository");
	    }
	 }
  	 public static ISMROLETBRepository GetSMROLETBRepository
	 {
	   get
	    {
	     return SpringHelper.GetObject<ISMROLETBRepository>("SMROLETBRepository");
	    }
	 }
  	 public static ISMUSERTBRepository GetSMUSERTBRepository
	 {
	   get
	    {
	     return SpringHelper.GetObject<ISMUSERTBRepository>("SMUSERTBRepository");
	    }
	 }
   }
}