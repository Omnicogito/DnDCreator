using CharCreator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Models
{
    public class StoryCharacter
    {
        public Story Story { get; set; }
        public IEnumerable<Character> Characters { get; set; }

        private List<int> _selectedCharacters;
        public List<int> SelectedCharacters
        {
            get
            {
                if (_selectedCharacters == null)
                {
                    _selectedCharacters = Characters.Select(m => m.ID).ToList();
                }
                return _selectedCharacters;
            }
            set { _selectedCharacters = value; }
        }
    }
}
