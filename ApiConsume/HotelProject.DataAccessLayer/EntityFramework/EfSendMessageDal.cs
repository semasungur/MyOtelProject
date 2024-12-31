﻿using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfSendMessageDal : GenericRepository<SendMessage>, ISendMessageDal
    {
        public EfSendMessageDal(Context context) : base(context)
        {
      
        }
        //İSTATİSTİK İÇİN VERİ ÇEKME
        public int GetSendMessageCount()
        {
            var context = new Context();
            var value = context.SendMessages.Count();
            return value;
        }
    }
   
}
