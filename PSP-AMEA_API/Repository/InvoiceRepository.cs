using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly List<Invoice> invoices = new()
        {
            new Invoice() {Id = Guid.NewGuid(), VATCode = "VATCode", Address = "Location1", CreatedAt = DateTime.Now, DueTo = DateTime.Now.AddDays(7), Amount = 100, Name = "Name1"},
            new Invoice() {Id = Guid.NewGuid(), VATCode = "VATCode", Address = "Location2", CreatedAt = DateTime.Now, DueTo = DateTime.Now.AddDays(14), Amount = 200, Name = "Name2"},
            new Invoice() {Id = Guid.NewGuid(), VATCode = "VATCode", Address = "Location3", CreatedAt = DateTime.Now, DueTo = DateTime.Now.AddDays(21), Amount = 300, Name = "Name3"}
        };

        public Invoice CreateInvoice(CreateInvoiceDto dto)
        {
            var invoice = new Invoice() { Id = Guid.NewGuid(), OrderId = dto.OrderId, VATCode = dto.VATCode, Address = dto.Address, CreatedAt = dto.CreatedAt, DueTo = dto.DueTo, Amount = dto.Amount, Name = dto.Name, TenantId = dto.TenantId};
            invoices.Add(invoice);
            return invoice;
        }

        public void UpdateInvoice(Invoice invoice)
        {
            var id = invoices.FindIndex(i => i.Id == invoice.Id);
            invoices[id] = invoice;
        }

        public void DeleteInvoice(Invoice invoice)
        {
            invoices.Remove(invoice);
        }

        public IEnumerable<Invoice> GetAllInvoices(int offset, int limit)
        {
            return invoices.Skip(offset).Take(limit);
        }

        public Invoice GetInvoiceById(Guid id)
        {
            return invoices.Find(i => i.Id == id);
        }
    }
}
