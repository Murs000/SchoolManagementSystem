using SchoolCore.Domain.Entities.Implementations;
using SchoolManagementSystem.Mappers.Interfaces;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Mappers.Implementations
{
    public class MarkMapper : IMarkMapper
    {
        public MarkModel Map(Mark mark)
        {
            MarkModel markmodel = new MarkModel();

            markmodel.Id = markmodel.Id;
            markmodel.Name = markmodel.Name;
            markmodel.Surname = markmodel.Surname;
            markmodel.FatherName = markmodel.FatherName;
            markmodel.BirthDate = markmodel.BirthDate;
            markmodel.Email = markmodel.Email;
            markmodel.PhoneNumber = markmodel.PhoneNumber;



            return markmodel;
        }

        public Mark Map(MarkModel markmodel)
        {
            Mark mark = new Mark();

            mark.Id = markmodel.Id;
            mark.Name = markmodel.Name;
            mark.Surname = markmodel.Surname;
            mark.BirthDate = markmodel.BirthDate;
            mark.Gender = markmodel.Gender;
            mark.Email = markmodel.Email;
            mark.PhoneNumber = markmodel.PhoneNumber;

            return mark;
        }

    }
}
