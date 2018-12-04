using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rbyte.Application.Tax.Create;
using Rbyte.Application.Tax.Read;
using Rbyte.Application.Tax.Update;
using Rbyte.Domain.Entities;
using Rbyte.Persistance;

namespace Rbyte.Application.Tax
{
    public interface ITaxService
    {
        void Create(CreateTaxModel model);
        ReadTaxModel Read(int taxId);
        IEnumerable<ReadTaxModel> Read();
        List<SelectListItem> GetTaxSelectList();
        UpdateTaxModel GetForEdition(int taxId);
        void Update(UpdateTaxModel model);
        void Delete(int taxId);
    }
    public class TaxService : ITaxService
    {
        private readonly RbyteContext _context;
        public TaxService(RbyteContext context)
        {
            _context = context;
        }

        public void Create(CreateTaxModel model)
        {
            _context.Add(new DbTax
            {
                Value = model.Value
            });
            _context.SaveChanges();
        }

        public void Delete(int taxId)
        {
            var dbTax = _context.Taxes.First(x => x.TaxId == taxId);
            _context.Taxes.Remove(dbTax);
            _context.SaveChanges();
        }

        public UpdateTaxModel GetForEdition(int taxId)
        {
            var tax = _context.Taxes.Where(x => x.TaxId == taxId)
                                    .Select(x => new UpdateTaxModel
                                    {
                                        TaxId = x.TaxId,
                                        Value = x.Value
                                    }).First();
            return tax;
        }

        public List<SelectListItem> GetTaxSelectList()
        {
            var taxList = _context.Taxes.Select(x => new SelectListItem
            {
                Text = x.Value.ToString(),
                Value = x.TaxId.ToString()
            }).ToList();
            return taxList;
        }

        public ReadTaxModel Read(int taxId)
        {
            var tax = _context.Taxes.Where(x => x.TaxId == taxId)
                                    .Select(x => new ReadTaxModel
                                    {
                                        TaxId = x.TaxId,
                                        Value = x.Value
                                    }).First();
            return tax;
        }

        public IEnumerable<ReadTaxModel> Read()
        {
            var taxes = _context.Taxes.Select(x => new ReadTaxModel
            {
                TaxId = x.TaxId,
                Value = x.Value
            }).ToList();
            return taxes;
        }

        public void Update(UpdateTaxModel model)
        {
            var dbTax = _context.Taxes.First(x => x.TaxId == model.TaxId);
            dbTax.Value = model.Value;
            _context.SaveChanges();
        }
    }
}