namespace _02.VaniPlanning
{
    using System;
    using System.Collections.Generic;
	using System.Linq;

	public class Agency : IAgency
    {
        private Dictionary<string, Invoice> invoicesByNumber;

        public Agency()
        {
            this.invoicesByNumber = new Dictionary<string, Invoice>();
        }

        public void Create(Invoice invoice)
        {
            if (this.invoicesByNumber.ContainsKey(invoice.SerialNumber))
            {
                throw new ArgumentException();
            }

            this.invoicesByNumber.Add(invoice.SerialNumber, invoice);
        }

        public bool Contains(string number) => this.invoicesByNumber.ContainsKey(number);

        public int Count() => this.invoicesByNumber.Count;

        public void PayInvoice(DateTime due)
        {
            int counter = 0;

            foreach (var invoice in this.invoicesByNumber.Values)
            {
                if (invoice.DueDate == due)
                {
                    invoice.Subtotal = 0;

                    counter++;
                }
            }

            if (counter == 0)
            {
                throw new ArgumentException();
            }
        }

        public void ThrowInvoice(string number)
        {
            if (!this.invoicesByNumber.ContainsKey(number))
            {
                throw new ArgumentException();
            }

            this.invoicesByNumber.Remove(number);
        }

        public void ThrowPayed()
        {
            this.invoicesByNumber = this.invoicesByNumber
                .Where(kvp => kvp.Value.Subtotal != 0)
                .ToDictionary(x => x.Key, x => x.Value);
        }

        public IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime start, DateTime end)
            => this.invoicesByNumber.Values
               .Where(i => i.IssueDate >= start && i.IssueDate <= end)
               .OrderBy(i => i.IssueDate)
               .ThenBy(i => i.DueDate);

        public IEnumerable<Invoice> SearchBySerialNumber(string serialNumber)
        {
            var filteredInvoices = this.invoicesByNumber.Values
                .Where(i => i.SerialNumber.Contains(serialNumber))
                .OrderByDescending(i => i.SerialNumber);

            if (filteredInvoices.Count() == 0)
            {
                throw new ArgumentException();
            }

            return filteredInvoices;
        }

        public IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime start, DateTime end)
        {
            var invoicesToRemove = this.invoicesByNumber.Values
                .Where(i => i.DueDate > start && i.DueDate < end);

            if (invoicesToRemove.Count() == 0)
            {
                throw new ArgumentException();
            }

            foreach (var invoice in invoicesToRemove)
            {
                this.invoicesByNumber.Remove(invoice.SerialNumber);
            }

            return invoicesToRemove;
        }

        public IEnumerable<Invoice> GetAllFromDepartment(Department department)
            => this.invoicesByNumber.Values
               .Where(i => i.Department == department)
               .OrderByDescending(i => i.Subtotal)
               .ThenBy(i => i.IssueDate);

        public IEnumerable<Invoice> GetAllByCompany(string company)
            => this.invoicesByNumber.Values
               .Where(i => i.CompanyName == company)
               .OrderByDescending(i => i.SerialNumber);

        public void ExtendDeadline(DateTime dueDate, int days)
        {
            int counter = 0;

            foreach (var invoice in this.invoicesByNumber.Values)
            {
                if (invoice.DueDate == dueDate)
                {
                    invoice.DueDate = invoice.DueDate.AddDays(days);

                    counter++;
                }
            }

            if (counter == 0)
            {
                throw new ArgumentException();
            }
        }
    }
}
