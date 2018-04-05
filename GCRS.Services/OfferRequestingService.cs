using System;
using System.Collections.Generic;
using System.Linq;
using GCRS.Domain;
using GCRS.Data;

namespace GCRS.Services
{
    public class OfferRequestingService
    {
        private UnitOfWork unitOfWork;

        public OfferRequestingService()
        {
            unitOfWork = new UnitOfWork();
        }

        public bool MakeRequest(Client Client)
        {
            if(unitOfWork.Repository<OfferRequest>().SingleOrDefault(o => o.ClientUsername == Client.Username) == null)
            {
                OfferRequest newReq = new OfferRequest()
                {
                    ClientUsername = Client.Username,
                    Client = Client,
                    State = RequestState.Requested,
                    RequestedDate = DateTime.Today
                };
                //TODO: Asignar un agente a la oferta
                unitOfWork.Repository<OfferRequest>().Add(newReq);
                unitOfWork.SaveChanges();
                return true;
            }
            return false;
        }

        public bool BindRequestToAgent(Agent Agent, OfferRequest Request)
        {
            if(Request.Agent != null)
            {
                throw new Exception("The Request already has an Agent");
            }
            Request.AgentUsername = Agent.Username;
            Request.Agent = Agent;
            return true;
        }

        public void CancelOfferRequest(OfferRequest Request)
        {
            Request.State = RequestState.Canceled;
        }
    }
}
