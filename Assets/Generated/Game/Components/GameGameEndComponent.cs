//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly GameEndComponent gameEndComponent = new GameEndComponent();

    public bool isGameEnd {
        get { return HasComponent(GameComponentsLookup.GameEnd); }
        set {
            if (value != isGameEnd) {
                var index = GameComponentsLookup.GameEnd;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : gameEndComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGameEnd;

    public static Entitas.IMatcher<GameEntity> GameEnd {
        get {
            if (_matcherGameEnd == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameEnd);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameEnd = matcher;
            }

            return _matcherGameEnd;
        }
    }
}