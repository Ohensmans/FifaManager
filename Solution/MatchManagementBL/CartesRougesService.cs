﻿using FifaDAL.MatchManagement;
using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MatchManagementBL
{
    public class CartesRougesService : MatchManagementService
    {
        public CartesRougesService()
        {
            this.name = "CartonsRouges";
        }

        //ajoute et supprime les participations nécessaires (qui ont été modifiées)
        public void SaveAll(DataView oView, Guid matchId, Guid equipeId)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    this.AddAll(oView, matchId, equipeId);
                    this.DeleteAll(oView);
                    this.UpdateAll(oView, matchId);

                    scope.Complete();
                }
            }

            catch (TechnicalError oErreur)
            {
                throw oErreur;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        // ajoute les lignes de joueurs inscrits qui ont été modifiées
        public void AddAll(DataView oView, Guid matchId, Guid equipeId)
        {
            try
            {
                oView.RowStateFilter = DataViewRowState.Added;
                if (oView.Count > 0)
                {
                    foreach (DataRowView rowView in oView)
                    {
                        List<dynamic> lstParam = new List<dynamic>();
                        lstParam.Add(rowView[0]);
                        lstParam.Add(matchId);
                        lstParam.Add(equipeId);
                        lstParam.Add(rowView[2]);

                        CartesRougesData crd = new CartesRougesData(_Connection);
                        crd.AddCarte(lstParam);
                    }
                }

            }

            catch (TechnicalError oErreur)
            {
                throw oErreur;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        // supprime les lignes de joueurs qui ne sont plus inscrits et qui ont été modifiées
        public void DeleteAll(DataView oView)
        {
            try
            {
                oView.RowStateFilter = DataViewRowState.Deleted;
                if (oView.Count > 0)
                {
                    foreach (DataRowView rowView in oView)
                    {

                        List<dynamic> lstParam = new List<dynamic>();
                        lstParam.Add(rowView[3]);

                        CartesRougesData crd = new CartesRougesData(_Connection);
                        crd.DeleteCarte(lstParam);
                    }
                }
            }

            catch (TechnicalError oErreur)
            {
                throw oErreur;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        // modifie les lignes de joueurs inscrits qui ont été modifiées
        public void UpdateAll(DataView oView, Guid matchId)
        {
            try
            {
                oView.RowStateFilter = DataViewRowState.ModifiedCurrent;
                if (oView.Count > 0)
                {
                    foreach (DataRowView rowView in oView)
                    {
                        DateTime Maint = DateTime.Now;

                        List<dynamic> lstParam = new List<dynamic>();
                        lstParam.Add(rowView[3]);
                        lstParam.Add(rowView[0]);
                        lstParam.Add(matchId);
                        lstParam.Add(rowView[2]);
                        lstParam.Add(rowView["lastUpdate"]);

                        CartesRougesData crd = new CartesRougesData(_Connection);
                        crd.UpdateCarte(lstParam);
                    }
                }

            }

            catch (TechnicalError oErreur)
            {
                throw oErreur;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Guid> getMatchsCartonsRouges(Guid joueurId, QuartersModele quarter)
        {
            try
            {
                List<Guid> lMatchId = new List<Guid>();
                DataView lCartons = this.loadAllData();

                foreach (DataRowView dr in lCartons)
                {
                    if (((Guid)dr["joueurId"] == joueurId)
                         && ((DateTime)(dr["matchDate"]) <= quarter.dateFin)
                         && ((DateTime)(dr["matchDate"]) >= quarter.dateDebut))
                    {
                        lMatchId.Add((Guid)dr["matchId"]);
                    }
                }
                return lMatchId;
            }
            catch (TechnicalError oErreur)
            {
                throw oErreur;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
