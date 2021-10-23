using System.Collections.Generic;

public class VisualNovelContext
{
    private readonly List<IVisualNovelSequence> _locationSequence;
    private readonly List<IVisualNovelSequence> _eventStartSequence;

    private readonly List<IVisualNovelSequence> _option1SuccessSequece;
    private readonly List<IVisualNovelSequence> _option1FailSequece;
    private readonly List<IVisualNovelSequence> _option2SuccessSequece;
    private readonly List<IVisualNovelSequence> _option2FailSequece;

    private readonly List<IVisualNovelSequence> _eventEndSequence;

    public VisualNovelContext()
    {

    }
}
