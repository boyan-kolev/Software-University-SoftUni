using System;
using System.Collections.Generic;
using System.Text;

namespace TeisterMask.DataProcessor.ExportDto
{
    public class ExportEmpoyeeDto
    {
        public string Username { get; set; }
        public ICollection<ExportTaskDto> Tasks { get; set; }
    }
}
