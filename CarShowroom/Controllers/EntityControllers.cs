using Showroom.Controllers;
using Showroom.Domain.Entities;
using Showroom.Domain.Entitis.CarEntities.Interface;

public class BodyController : GenericController<Body>
{
    public BodyController(IRepository<Body> repository) : base(repository) { }
}

public class BrandController : GenericController<Brand>
{
    public BrandController(IRepository<Brand> repository) : base(repository) { }
}

public class ShowroomController : GenericController<CarShowroom>
{
    public ShowroomController(IRepository<CarShowroom> repository) : base(repository) { }
}

public class ClassController : GenericController<Class>
{
    public ClassController(IRepository<Class> repository) : base(repository) { }
}

public class EngineController : GenericController<Engine>
{
    public EngineController(IRepository<Engine> repository) : base(repository) { }
}

public class GearboxController : GenericController<Gearbox>
{
    public GearboxController(IRepository<Gearbox> repository) : base(repository) { }
}

public class GenerationController : GenericController<Generation>
{
    public GenerationController(IRepository<Generation> repository) : base(repository) { }
}

public class ModelController : GenericController<Model>
{
    public ModelController(IRepository<Model> repository) : base(repository) { }
}

public class OptionController : GenericController<Option>
{
    public OptionController(IRepository<Option> repository) : base(repository) { }
}

public class StateController : GenericController<State>
{
    public StateController(IRepository<State> repository) : base(repository) { }
}

public class ElementController : GenericController<StateElement>
{
    public ElementController(IRepository<StateElement> repository) : base(repository) { }
}


