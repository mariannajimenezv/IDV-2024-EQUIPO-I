public abstract class AMenuState : IState
{
    protected IMenu menu;

    // Constructor
    public AMenuState(IMenu menu) => this.menu = menu;

    // Propiedades y transiciones de estado
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
    public abstract void FixedUpdate();

    //---- MÉTODOS DE BOTONES UTILIZADOS EN LOS MENÚS ----

    public virtual void OnTutorial() {}
    public virtual void OnPlay(){}
    public virtual void OnSettings() {}
    public virtual void OnCredits() {}

    public virtual void OnStartGame() {}
 
    public virtual void OnMainMenu() {}
    public virtual void OnBack() {}
    
}
