using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IVisualNovelContext
{
    void AdvanceSequence();
    bool CanSelectOption();
    void SelectOption(int option);
}