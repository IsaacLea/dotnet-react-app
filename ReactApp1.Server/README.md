
# Implementation notes
- Using AutoMapper to map between DTOs and Entities can introduce performance overhead since it uses reflection. For large datasets, consider manual mapping.
- The db context SaveChanges method has been overridden to include auto population of the CreateTime column