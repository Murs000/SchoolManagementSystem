using SchoolCore.Domain.Entities.Implementations;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Mappers.Interfaces
{
    public interface IMarkMapper
    {
        MarkModel Map(Mark mark);
        Mark Map(MarkModel markModel);
    }
}
