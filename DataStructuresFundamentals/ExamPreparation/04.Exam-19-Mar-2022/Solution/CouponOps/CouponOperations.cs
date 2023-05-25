namespace CouponOps
{
    using System;
    using System.Collections.Generic;
	using System.Linq;
	using CouponOps.Models;
    using Interfaces;

    public class CouponOperations : ICouponOperations
    {
        private readonly Dictionary<string, Website> websitesByDomain = new Dictionary<string, Website>();

        private readonly Dictionary<string, Coupon> couponsByCode = new Dictionary<string, Coupon>();

        public void RegisterSite(Website website)
        {
            if (this.websitesByDomain.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }

            this.websitesByDomain.Add(website.Domain, website);
        }
 
        public void AddCoupon(Website website, Coupon coupon)
        {
            if (!this.websitesByDomain.ContainsKey(website.Domain)
                || this.couponsByCode.ContainsKey(coupon.Code))
            {
                throw new ArgumentException();
            }

            this.couponsByCode.Add(coupon.Code, coupon);

            this.couponsByCode[coupon.Code].Website = website;

            this.websitesByDomain[website.Domain].Coupons.Add(coupon);
        }

        public Website RemoveWebsite(string domain)
        {
            if (!this.websitesByDomain.ContainsKey(domain))
            {
                throw new ArgumentException();
            }

            Website website = this.websitesByDomain[domain];

            foreach (var coupon in website.Coupons)
            {
                this.couponsByCode.Remove(coupon.Code);
            }

            this.websitesByDomain.Remove(domain);

            return website;
        }

        public Coupon RemoveCoupon(string code)
        {
            if (!this.couponsByCode.ContainsKey(code))
            {
                throw new ArgumentException();
            }

            Coupon coupon = this.couponsByCode[code];

            Website website = coupon.Website;

            website.Coupons.Remove(coupon);

            this.couponsByCode.Remove(code);

            return coupon;
        }

        public bool Exist(Website website) => this.websitesByDomain.ContainsKey(website.Domain);

        public bool Exist(Coupon coupon) => this.couponsByCode.ContainsKey(coupon.Code);

        public IEnumerable<Website> GetSites() => this.websitesByDomain.Values;

        public IEnumerable<Coupon> GetCouponsForWebsite(Website website)
        {
            if (!this.websitesByDomain.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }

            return this.websitesByDomain[website.Domain].Coupons;
        }

        public void UseCoupon(Website website, Coupon coupon)
        {
            if (!this.websitesByDomain.ContainsKey(website.Domain)
                || !this.couponsByCode.ContainsKey(coupon.Code)
                || this.couponsByCode[coupon.Code].Website != website)
            {
                throw new ArgumentException();
            }

            this.websitesByDomain[website.Domain].Coupons.Remove(coupon);

            this.couponsByCode.Remove(coupon.Code);
        }

        public IEnumerable<Coupon> GetCouponsOrderedByValidityDescAndDiscountPercentageDesc()
            => this.couponsByCode.Values
                .OrderByDescending(c => c.Validity)
                .ThenByDescending(c => c.DiscountPercentage);

        public IEnumerable<Website> GetWebsitesOrderedByUserCountAndCouponsCountDesc()
            => this.websitesByDomain.Values
                .OrderBy(w => w.UsersCount)
                .ThenByDescending(w => w.Coupons.Count);
    }
}
