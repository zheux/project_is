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
                    AgentUsername = "agente",
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

        public bool BindRequestToAgent(Agent Agent, Client Client)
        {
            OfferRequest Request = unitOfWork.Repository<OfferRequest>().SingleOrDefault(o => o.ClientUsername == Client.Username);
            if(Request.Agent != null)
            {
                throw new Exception("The Request already has an Agent");
            }
            Request.AgentUsername = Agent.Username;
            unitOfWork.SaveChanges();
            return true;
        }

        public void AcceptRequest(Agent Agent, Client Client)
        {
            OfferRequest Request = unitOfWork.Repository<OfferRequest>().SingleOrDefault(o => o.ClientUsername == Client.Username);
            Request.State = RequestState.Draft;
            unitOfWork.SaveChanges();
        }

        public void RemoveRequest(Client Client)
        {
            OfferRequest Request = unitOfWork.Repository<OfferRequest>().SingleOrDefault(o => o.ClientUsername == Client.Username);
            Request.isDeleted = true;
            unitOfWork.SaveChanges();
        }

        public void CancelOfferRequest(Client Client)
        {
            OfferRequest Request = unitOfWork.Repository<OfferRequest>().SingleOrDefault(o => o.ClientUsername == Client.Username);
            Request.State = RequestState.Canceled;
        }
    }
}
