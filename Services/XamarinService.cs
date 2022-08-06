using LastWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LastWebApi.Services
{
    public class XamarinService
    {
        public int AddUser(User user)
        {
            using (var context = new ProjectDbEntities6())
            {
                context.Configuration.ProxyCreationEnabled = false;
                if (user != null)
                {
                    if (context.User.Where(x => x.UserName.Equals(user.UserName)).FirstOrDefault() == null)
                    {
                        context.User.Add(user);
                        context.SaveChanges();
                        return 1;
                    }

                }
            }
            return 0;
        }
        public int DeleteUser(int id)
        {
            using(var context = new ProjectDbEntities6())
            {
                User user = context.User.Where(x => x.UserId == id).FirstOrDefault();
                if (user != null)
                {
                    context.User.Remove(user);
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public User LoginFunction(string username,string password)
        {
            using(var context = new ProjectDbEntities6())
            {
                context.Configuration.ProxyCreationEnabled = false;
                context.Configuration.LazyLoadingEnabled = false;

                return context.User.Where(x => x.UserName.Equals(username) && x.Password.Equals(password)).FirstOrDefault();  
            }
        }
        public List<User> GetUsers()
        {
            using(var context = new ProjectDbEntities6())
            {
                context.Configuration.ProxyCreationEnabled = false;

                return context.User.ToList<User>();
            }
        }
        public List<Policy> GetPoliciesByUserId(int userid)
        {
            using(var context = new ProjectDbEntities6())
            {
                context.Configuration.ProxyCreationEnabled = false;

                return context.Policy.Where(x => x.UserId == userid).ToList<Policy>();
            }
        }
        public Policy[] GetPolicies()
        {
            using(var context = new ProjectDbEntities6())
            {
                context.Configuration.ProxyCreationEnabled = false;

                Policy[] policies = context.Policy.ToArray<Policy>();
                if(policies.Length != 0)
                {
                    return policies;
                }
                else
                {
                    return null;
                }
            }
        }
        public int DeletePolicy(int policeno)
        {
            using(var context = new ProjectDbEntities6())
            {
                Policy police = context.Policy.Where(x => x.PoliceNo == policeno).FirstOrDefault();
                if(police != null)
                {
                    context.Policy.Remove(police);
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public int AddPolicy(Policy policy)
        {
            using (var context = new ProjectDbEntities6())
            {
                if(policy != null)
                {
                    context.Policy.Add(policy);
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public  CarPolicy GetCarPolicy(int policeno)
        {
            using(var context = new ProjectDbEntities6())
            {
                context.Configuration.ProxyCreationEnabled = false;
                CarPolicy carpolicy = context.CarPolicy.Where(x => x.PoliceNo == policeno).FirstOrDefault();
                return carpolicy;
            }
        }
        public int AddCarPolicy(CarPolicy carPolicy)
        {
            using(var context = new ProjectDbEntities6())
            {
                if (carPolicy != null)
                {
                    context.CarPolicy.Add(carPolicy);
                    context.SaveChanges();
                }
                else
                {
                    return 0;
                }
            }
            return 1;
        }
        public int DeleteCarPolicy(int policeno)
        {
            using(var context = new ProjectDbEntities6())
            {
                CarPolicy carPolicy = context.CarPolicy.Where(x => x.PoliceNo == policeno).FirstOrDefault();
                if(carPolicy == null)
                {
                    return 0;
                }
                else
                {
                    context.CarPolicy.Remove(carPolicy);
                    context.SaveChanges();
                }

            }
            return 1;
        }
      

    }
}