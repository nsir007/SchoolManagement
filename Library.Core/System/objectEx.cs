using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

public static class objectEx
  {
	#region Methods

    public static T CastTo<T>(this object o)
	{
		return (T)o;
	}

	//public static T CloneTo<T>(this object toClone)
	//	{
	//		Type sourceType = toClone.GetType();
 //     Type targetType = typeof(T);
 //     PropertyInfo[] sourceProps = sourceType.GetProperties();//s prop
 //     PropertyInfo[] targetProps = targetType.GetProperties();//t prop
 //     ConstructorInfo construct = targetType.GetConstructor(new Type[] { });//target constructor
 //     object instance = construct.Invoke(new object[] { });//t instance
 //     foreach (PropertyInfo pi in sourceProps)
 //     {
 //         IEnumerable<PropertyInfo> q = from p in targetProps
 //                                where p.Name == pi.Name
 //                                select p;
 //         if (q.Count() > 0)
 //         {
 //             PropertyInfo p = q.First<PropertyInfo>();
 //             try
 //             {
 //                 p.SetValue(instance, pi.GetValue(toClone, null), null);
 //             }
 //             catch { }
 //         }
 //     }
 //     return instance.CastTo<T>();
	//	}
    
    public static bool IsConvertableToDate(this object o)
    {
        if (o.IsNotNullOrEmpty())
        {
            bool done = false;
            try
            {
                DateTime dt = Convert.ToDateTime(o);
                if (dt.IsNotNull())
                {
                    done = true;
                }
            }
            catch { }
            return done;
        }
        return false;
    }

    public static bool IsNotNull(this object s)
    {
        return null != s;
    }

    public static bool IsNotNullOrEmpty(this object s)
    {
        return !s.IsNullOrEmpty();
    }

    public static bool IsNull(this object s)
    {
        return null == s;
    }

    public static bool IsNullOrEmpty(this object s)
    {
        return "".IsNullOrEmpty(s);
    }

    public static bool IsNullOrEmptyOrDbNull(this object objectToCheck)
    {
      return (objectToCheck.IsNullOrEmpty() || objectToCheck == DBNull.Value);
    }
    
    public static bool IsNotNullOrEmptyOrDbNull(this object objectToCheck)
    {
      return !(objectToCheck.IsNullOrEmpty() || objectToCheck == DBNull.Value);
    }

    public static bool IsNullOrEmpty(this object o, object toCheck)
    {
        if (null == toCheck)
            return true;
        if (String.IsNullOrEmpty(toCheck.ToString().Trim()))
            return true;

        return false;
    }

    public static bool MatchByString(this object o, object objectToMatch)
    {
        return "".MatchByString(o, objectToMatch);
    }

    public static bool MatchByString(this object o, object object1, object object2)
    {
        if ("".IsNullOrEmpty(object1) && "".IsNullOrEmpty(object2))
            return true;

        if ("".IsNullOrEmpty(object1) || "".IsNullOrEmpty(object2))
            return false;

        return object1.ToString().Trim().ToLower() == object2.ToString().Trim().ToLower();
    }

    public static string Text(this object o)
    {
        if (null == o)
        {
            return string.Empty;
        }
        return o.ToString();
    }

 
    public static bool Validate(this object o, out List<ValidationResult> validationResults)
    {
        var context = new ValidationContext(o, serviceProvider: null, items: null);

        validationResults = new List<ValidationResult>();

        return Validator.TryValidateObject(o, context, validationResults, true);
    }
        
    #endregion Methods 
  }

