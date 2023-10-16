using System;
using System.Collections.Generic;

namespace lr2_entity;

public partial class Клиент
{
    public int КодКлиента { get; set; }

    public string Фирма { get; set; } = null!;

    public string Фамилия { get; set; } = null!;

    public string Город { get; set; } = null!;

    public string Телефон { get; set; } = null!;

    public virtual ICollection<Сделка> Сделкаs { get; set; } = new List<Сделка>();
}
