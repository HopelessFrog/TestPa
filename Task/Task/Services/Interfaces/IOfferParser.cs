using System;
using System.Collections.Generic;
using System.Text;
using Task.Model;

namespace Task.Services.Interfaces
{
    public interface IOfferParser 
    {
        System.Threading.Tasks.Task<List<Offer>> Parse();

    }
}
