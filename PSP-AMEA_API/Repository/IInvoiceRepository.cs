using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public interface IInvoiceRepository
    {
        Invoice CreateInvoice(CreateInvoiceDto dto);
        void UpdateInvoice(Invoice invoice);
        void DeleteInvoice(Invoice invoice);
        IEnumerable<Invoice> GetAllInvoices(int offset, int limit);
        Invoice GetInvoiceById(Guid id);
    }
}
