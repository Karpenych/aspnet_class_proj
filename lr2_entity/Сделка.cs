using System;
using System.Collections.Generic;

namespace lr2_entity;

public partial class Сделка
{
    public int КодСделки { get; set; }

    public int КодТовара { get; set; }

    public int КодКлиента { get; set; }

    public int Количество { get; set; }

    public DateTime Дата { get; set; }

    public virtual Клиент КодКлиентаNavigation { get; set; } = null!;

    public virtual Товар КодТовараNavigation { get; set; } = null!;
}
