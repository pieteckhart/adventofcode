using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Xsl;

namespace Advent
{
    public class CustomsDeclarationsScanner
    {
        private string[] forms;

        public CustomsDeclarationsScanner(string input)
        {
            var forms = input.Split(Environment.NewLine + Environment.NewLine);
            this.forms = forms;
        }

        public int Scan(string input)
        {
            input = input.Replace("\r\n", "");
            IEnumerable<char> answers = new List<char>(input);
            return answers.Distinct().Count();
        }

        public int ScanSumDistinct()
        {
            return forms.Sum(Scan);
        }

        public int ScanSumUnanimous()
        {
            return forms.Sum(ScanUnanimous);
        }

        private int ScanUnanimous(string input)
        {
            var individualForms = input.Split(Environment.NewLine);
            var test = individualForms[0].ToList();

            foreach (var form in individualForms)
            {
                var newForm = form.ToList();
                test = test.Intersect(newForm).ToList();
            }

            return test.Count;
        }
    }
}
