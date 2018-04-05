using System;
using System.Collections.Generic;
using System.Linq;
using GCRS.Domain;
using GCRS.Data.Repositories;

namespace GCRS.Services
{
    public class OfferRequestingService
    {
        private OfferRequestRepository _offerReqRepo;

        public OfferRequestingService()
        {
            _offerReqRepo = new OfferRequestRepository();
        }

        public bool MakeRequest(Client Client)
        {
            if(_offerReqRepo.GetOfferRequests().SingleOrDefault(o => o.ClientUsername == Client.Username) == null)
            {
                OfferRequest newReq = new OfferRequest()
                {
                    ClientUsername = Client.Username,
                    Client = Client,
                    State = RequestState.Requested,
                    RequestedDate = DateTime.Today
                };
                //TODO: Asignar un agente a la oferta
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
