using System;
using System.Collections.Generic;

namespace ReactApp1.Server.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string Street { get; set; } = null!;

    public string Province { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
