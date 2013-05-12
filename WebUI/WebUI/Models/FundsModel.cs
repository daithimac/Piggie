using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Web.Routing;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class CreatePaymentCardModel
    {
        public String Title { get; set; }
        public String Name { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String CardNumber { get; set; }
        public String CardType { get; set; }
        public String CCV { get; set; }
    }

    public class SummaryFund
    {
        
        public String Name { get; set; }
        public Decimal Amount { get; set; }
        public Decimal Balance { get; set; }
        public Decimal GoalAmount { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseOn { get; set; }
        public String Frequency { get; set; }
    }

    public class SummaryModel
    {
        public List<SummaryFund> Funds { get; set; }
    }

    public class CreateFundModel
    {
        [Required(ErrorMessage = "Name is required")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Goal Amount is required")]
        [Range(1, 10000, ErrorMessage = "Price must be between €1 and €10,000")]
        [DataType(DataType.Currency)]
        public Decimal GoalAmount { get; set; }
        [Required(ErrorMessage = "Release Date is required")]
        [DataType(DataType.Date)]
        public DateTime ReleaseOn { get; set; }
        [Required(ErrorMessage = "Frequency is required")]
        public String Frequency { get; set; }
        public int FreqId { get; set; }
        public String RecipiantAccount { get; set; }
        
    }
     /*public MvcHtmlString Meter(string name, string innerText, double min, double max, double value, object htmlAttributes)
        {
            TagBuilder tagBuilder = new TagBuilder("meter");
            if (htmlAttributes != null)
            {
                RouteValueDictionary routeValueDictionary = new RouteValueDictionary(htmlAttributes);
                tagBuilder.MergeAttributes(routeValueDictionary);
            }
            if (value != -1)
                tagBuilder.MergeAttribute("value", value.ToString());
            if (max != -1)
                tagBuilder.MergeAttribute("max", max.ToString());
            if (min != -1)
                tagBuilder.MergeAttribute("min", min.ToString());
            tagBuilder.MergeAttribute("id", name);
            tagBuilder.InnerHtml = innerText;
            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        } */

    public class CreditCardAttribute : ValidationAttribute 
    {
        private CardType _cardTypes;
        public CardType AcceptedCardTypes
        {
            get { return _cardTypes; }
            set { _cardTypes = value; }
        }

        public CreditCardAttribute()
        {
            _cardTypes = CardType.All;
        }

        public CreditCardAttribute(CardType AcceptedCardTypes)
        {
            _cardTypes = AcceptedCardTypes;
        }

        public override bool IsValid(object value)
        {
            var number = Convert.ToString(value); 

            if (String.IsNullOrEmpty(number))
                return true;

            return IsValidType(number, _cardTypes) && IsValidNumber(number);
        }

        public override string FormatErrorMessage(string name)
        {
            return "The " + name + " field contains an invalid credit card number.";
        }

        public enum CardType
        {
            Unknown = 1,
            Visa = 2,
            MasterCard = 4,
            Amex = 8,
            Diners = 16,

            All = CardType.Visa | CardType.MasterCard | CardType.Amex | CardType.Diners,
            AllOrUnknown = CardType.Unknown | CardType.Visa | CardType.MasterCard | CardType.Amex | CardType.Diners
        }

        private bool IsValidType(string cardNumber, CardType cardType)
        {
            // Visa
            if (Regex.IsMatch(cardNumber, "^(4)")
            && ((cardType & CardType.Visa) != 0))
                return cardNumber.Length == 13 || cardNumber.Length == 16;

            // MasterCard
            if (Regex.IsMatch(cardNumber, "^(51|52|53|54|55)")
            && ((cardType & CardType.MasterCard) != 0))
                return cardNumber.Length == 16;

            // Amex
            if (Regex.IsMatch(cardNumber, "^(34|37)")
            && ((cardType & CardType.Amex) != 0))
                return cardNumber.Length == 15;

            // Diners
            if (Regex.IsMatch(cardNumber, "^(300|301|302|303|304|305|36|38)")
            && ((cardType & CardType.Diners) != 0))
                return cardNumber.Length == 14;

            //Unknown
            if ((cardType & CardType.Unknown) != 0)
                return true;

            return false;
        }

        private bool IsValidNumber(string number)
        {
            int[] DELTAS = new int[] { 0, 1, 2, 3, 4, -4, -3, -2, -1, 0 };
            int checksum = 0;
            char[] chars = number.ToCharArray();
            for (int i = chars.Length - 1; i > -1; i--)
            {
                int j = ((int)chars[i]) - 48;
                checksum += j;
                if (((i - chars.Length) % 2) == 0)
                    checksum += DELTAS[j];
            }

            return ((checksum % 10) == 0);
        }

       
    }
}