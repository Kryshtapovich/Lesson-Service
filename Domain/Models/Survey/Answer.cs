﻿using System;

namespace Domain.Models.Survey
{
    public class Answer
    {
        public int Id { get; set; }
        public Guid SurveyId { get; set; }
        public string Text { get; set; }
        public Image Image { get; set; }

        public int? OptionId { get; set; }
        public Option Option { get; set; }

        public int QuestionMessageId { get; set; }
        public QuestionMessage QuestionMessage { get; set; }
    }

    public class AnswerDto
    {
        public int Id { get; set; }
        public Option Option { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
    }
}
