extern "C" void RegisterStaticallyLinkedModulesGranular()
{
	void RegisterModule_SharedInternals();
	RegisterModule_SharedInternals();

	void RegisterModule_Core();
	RegisterModule_Core();

	void RegisterModule_Animation();
	RegisterModule_Animation();

	void RegisterModule_Audio();
	RegisterModule_Audio();

	void RegisterModule_GraphicsStateCollectionSerializer();
	RegisterModule_GraphicsStateCollectionSerializer();

	void RegisterModule_Grid();
	RegisterModule_Grid();

	void RegisterModule_HierarchyCore();
	RegisterModule_HierarchyCore();

	void RegisterModule_IMGUI();
	RegisterModule_IMGUI();

	void RegisterModule_Input();
	RegisterModule_Input();

	void RegisterModule_InputLegacy();
	RegisterModule_InputLegacy();

	void RegisterModule_InputForUI();
	RegisterModule_InputForUI();

	void RegisterModule_JSONSerialize();
	RegisterModule_JSONSerialize();

	void RegisterModule_Physics();
	RegisterModule_Physics();

	void RegisterModule_Physics2D();
	RegisterModule_Physics2D();

	void RegisterModule_Properties();
	RegisterModule_Properties();

	void RegisterModule_RuntimeInitializeOnLoadManagerInitializer();
	RegisterModule_RuntimeInitializeOnLoadManagerInitializer();

	void RegisterModule_SpriteShape();
	RegisterModule_SpriteShape();

	void RegisterModule_Tilemap();
	RegisterModule_Tilemap();

	void RegisterModule_SpriteMask();
	RegisterModule_SpriteMask();

	void RegisterModule_Terrain();
	RegisterModule_Terrain();

	void RegisterModule_TextRendering();
	RegisterModule_TextRendering();

	void RegisterModule_TextCoreFontEngine();
	RegisterModule_TextCoreFontEngine();

	void RegisterModule_TextCoreTextEngine();
	RegisterModule_TextCoreTextEngine();

	void RegisterModule_UI();
	RegisterModule_UI();

	void RegisterModule_UIElements();
	RegisterModule_UIElements();

	void RegisterModule_UnityAnalyticsCommon();
	RegisterModule_UnityAnalyticsCommon();

	void RegisterModule_Subsystems();
	RegisterModule_Subsystems();

	void RegisterModule_VFX();
	RegisterModule_VFX();

	void RegisterModule_VR();
	RegisterModule_VR();

	void RegisterModule_WebGL();
	RegisterModule_WebGL();

	void RegisterModule_XR();
	RegisterModule_XR();

}

template <typename T> void RegisterUnityClass(const char*);
template <typename T> void RegisterStrippedType(int, const char*, const char*);

void InvokeRegisterStaticallyLinkedModuleClasses()
{
	// Do nothing (we're in stripping mode)
}

class Animator; template <> void RegisterUnityClass<Animator>(const char*);
class AnimatorController; template <> void RegisterUnityClass<AnimatorController>(const char*);
class AnimatorOverrideController; template <> void RegisterUnityClass<AnimatorOverrideController>(const char*);
class RuntimeAnimatorController; template <> void RegisterUnityClass<RuntimeAnimatorController>(const char*);
class AudioBehaviour; template <> void RegisterUnityClass<AudioBehaviour>(const char*);
class AudioClip; template <> void RegisterUnityClass<AudioClip>(const char*);
class AudioListener; template <> void RegisterUnityClass<AudioListener>(const char*);
class AudioManager; template <> void RegisterUnityClass<AudioManager>(const char*);
class AudioMixer; template <> void RegisterUnityClass<AudioMixer>(const char*);
class AudioResource; template <> void RegisterUnityClass<AudioResource>(const char*);
class AudioSource; template <> void RegisterUnityClass<AudioSource>(const char*);
class SampleClip; template <> void RegisterUnityClass<SampleClip>(const char*);
class Behaviour; template <> void RegisterUnityClass<Behaviour>(const char*);
class BuildSettings; template <> void RegisterUnityClass<BuildSettings>(const char*);
class Camera; template <> void RegisterUnityClass<Camera>(const char*);
namespace Unity { class Component; } template <> void RegisterUnityClass<Unity::Component>(const char*);
class ComputeShader; template <> void RegisterUnityClass<ComputeShader>(const char*);
class Cubemap; template <> void RegisterUnityClass<Cubemap>(const char*);
class CubemapArray; template <> void RegisterUnityClass<CubemapArray>(const char*);
class DelayedCallManager; template <> void RegisterUnityClass<DelayedCallManager>(const char*);
class EditorExtension; template <> void RegisterUnityClass<EditorExtension>(const char*);
class GameManager; template <> void RegisterUnityClass<GameManager>(const char*);
class GameObject; template <> void RegisterUnityClass<GameObject>(const char*);
class GlobalGameManager; template <> void RegisterUnityClass<GlobalGameManager>(const char*);
class GraphicsSettings; template <> void RegisterUnityClass<GraphicsSettings>(const char*);
class InputManager; template <> void RegisterUnityClass<InputManager>(const char*);
class LODGroup; template <> void RegisterUnityClass<LODGroup>(const char*);
class LevelGameManager; template <> void RegisterUnityClass<LevelGameManager>(const char*);
class Light; template <> void RegisterUnityClass<Light>(const char*);
class LightProbeProxyVolume; template <> void RegisterUnityClass<LightProbeProxyVolume>(const char*);
class LightProbes; template <> void RegisterUnityClass<LightProbes>(const char*);
class LightingSettings; template <> void RegisterUnityClass<LightingSettings>(const char*);
class LightmapSettings; template <> void RegisterUnityClass<LightmapSettings>(const char*);
class LineRenderer; template <> void RegisterUnityClass<LineRenderer>(const char*);
class LowerResBlitTexture; template <> void RegisterUnityClass<LowerResBlitTexture>(const char*);
class Material; template <> void RegisterUnityClass<Material>(const char*);
class Mesh; template <> void RegisterUnityClass<Mesh>(const char*);
class MeshFilter; template <> void RegisterUnityClass<MeshFilter>(const char*);
class MeshRenderer; template <> void RegisterUnityClass<MeshRenderer>(const char*);
class MonoBehaviour; template <> void RegisterUnityClass<MonoBehaviour>(const char*);
class MonoManager; template <> void RegisterUnityClass<MonoManager>(const char*);
class MonoScript; template <> void RegisterUnityClass<MonoScript>(const char*);
class NamedObject; template <> void RegisterUnityClass<NamedObject>(const char*);
class Object; template <> void RegisterUnityClass<Object>(const char*);
class PlayerSettings; template <> void RegisterUnityClass<PlayerSettings>(const char*);
class PreloadData; template <> void RegisterUnityClass<PreloadData>(const char*);
class QualitySettings; template <> void RegisterUnityClass<QualitySettings>(const char*);
class RayTracingShader; template <> void RegisterUnityClass<RayTracingShader>(const char*);
namespace UI { class RectTransform; } template <> void RegisterUnityClass<UI::RectTransform>(const char*);
class ReflectionProbe; template <> void RegisterUnityClass<ReflectionProbe>(const char*);
class RenderSettings; template <> void RegisterUnityClass<RenderSettings>(const char*);
class RenderTexture; template <> void RegisterUnityClass<RenderTexture>(const char*);
class Renderer; template <> void RegisterUnityClass<Renderer>(const char*);
class ResourceManager; template <> void RegisterUnityClass<ResourceManager>(const char*);
class RuntimeInitializeOnLoadManager; template <> void RegisterUnityClass<RuntimeInitializeOnLoadManager>(const char*);
class Shader; template <> void RegisterUnityClass<Shader>(const char*);
class ShaderNameRegistry; template <> void RegisterUnityClass<ShaderNameRegistry>(const char*);
class Skybox; template <> void RegisterUnityClass<Skybox>(const char*);
class SortingGroup; template <> void RegisterUnityClass<SortingGroup>(const char*);
class Sprite; template <> void RegisterUnityClass<Sprite>(const char*);
class SpriteAtlas; template <> void RegisterUnityClass<SpriteAtlas>(const char*);
class SpriteRenderer; template <> void RegisterUnityClass<SpriteRenderer>(const char*);
class TagManager; template <> void RegisterUnityClass<TagManager>(const char*);
class TextAsset; template <> void RegisterUnityClass<TextAsset>(const char*);
class Texture; template <> void RegisterUnityClass<Texture>(const char*);
class Texture2D; template <> void RegisterUnityClass<Texture2D>(const char*);
class Texture2DArray; template <> void RegisterUnityClass<Texture2DArray>(const char*);
class Texture3D; template <> void RegisterUnityClass<Texture3D>(const char*);
class TimeManager; template <> void RegisterUnityClass<TimeManager>(const char*);
class TrailRenderer; template <> void RegisterUnityClass<TrailRenderer>(const char*);
class Transform; template <> void RegisterUnityClass<Transform>(const char*);
class GridLayout; template <> void RegisterUnityClass<GridLayout>(const char*);
class Collider; template <> void RegisterUnityClass<Collider>(const char*);
class PhysicsManager; template <> void RegisterUnityClass<PhysicsManager>(const char*);
class Rigidbody; template <> void RegisterUnityClass<Rigidbody>(const char*);
class Collider2D; template <> void RegisterUnityClass<Collider2D>(const char*);
class EdgeCollider2D; template <> void RegisterUnityClass<EdgeCollider2D>(const char*);
class Physics2DSettings; template <> void RegisterUnityClass<Physics2DSettings>(const char*);
class PolygonCollider2D; template <> void RegisterUnityClass<PolygonCollider2D>(const char*);
class Rigidbody2D; template <> void RegisterUnityClass<Rigidbody2D>(const char*);
class SpriteShapeRenderer; template <> void RegisterUnityClass<SpriteShapeRenderer>(const char*);
class Terrain; template <> void RegisterUnityClass<Terrain>(const char*);
class TerrainData; template <> void RegisterUnityClass<TerrainData>(const char*);
namespace TextRendering { class Font; } template <> void RegisterUnityClass<TextRendering::Font>(const char*);
class Tilemap; template <> void RegisterUnityClass<Tilemap>(const char*);
class TilemapRenderer; template <> void RegisterUnityClass<TilemapRenderer>(const char*);
namespace UI { class Canvas; } template <> void RegisterUnityClass<UI::Canvas>(const char*);
namespace UI { class CanvasGroup; } template <> void RegisterUnityClass<UI::CanvasGroup>(const char*);
namespace UI { class CanvasRenderer; } template <> void RegisterUnityClass<UI::CanvasRenderer>(const char*);
class UIRenderer; template <> void RegisterUnityClass<UIRenderer>(const char*);
class VFXManager; template <> void RegisterUnityClass<VFXManager>(const char*);
class VFXRenderer; template <> void RegisterUnityClass<VFXRenderer>(const char*);
class VisualEffect; template <> void RegisterUnityClass<VisualEffect>(const char*);
class VisualEffectAsset; template <> void RegisterUnityClass<VisualEffectAsset>(const char*);
class VisualEffectObject; template <> void RegisterUnityClass<VisualEffectObject>(const char*);

void RegisterAllClasses()
{
void RegisterBuiltinTypes();
RegisterBuiltinTypes();
	//Total: 95 non stripped classes
	//0. Animator
	RegisterUnityClass<Animator>("Animation");
	//1. AnimatorController
	RegisterUnityClass<AnimatorController>("Animation");
	//2. AnimatorOverrideController
	RegisterUnityClass<AnimatorOverrideController>("Animation");
	//3. RuntimeAnimatorController
	RegisterUnityClass<RuntimeAnimatorController>("Animation");
	//4. AudioBehaviour
	RegisterUnityClass<AudioBehaviour>("Audio");
	//5. AudioClip
	RegisterUnityClass<AudioClip>("Audio");
	//6. AudioListener
	RegisterUnityClass<AudioListener>("Audio");
	//7. AudioManager
	RegisterUnityClass<AudioManager>("Audio");
	//8. AudioMixer
	RegisterUnityClass<AudioMixer>("Audio");
	//9. AudioResource
	RegisterUnityClass<AudioResource>("Audio");
	//10. AudioSource
	RegisterUnityClass<AudioSource>("Audio");
	//11. SampleClip
	RegisterUnityClass<SampleClip>("Audio");
	//12. Behaviour
	RegisterUnityClass<Behaviour>("Core");
	//13. BuildSettings
	RegisterUnityClass<BuildSettings>("Core");
	//14. Camera
	RegisterUnityClass<Camera>("Core");
	//15. Component
	RegisterUnityClass<Unity::Component>("Core");
	//16. ComputeShader
	RegisterUnityClass<ComputeShader>("Core");
	//17. Cubemap
	RegisterUnityClass<Cubemap>("Core");
	//18. CubemapArray
	RegisterUnityClass<CubemapArray>("Core");
	//19. DelayedCallManager
	RegisterUnityClass<DelayedCallManager>("Core");
	//20. EditorExtension
	RegisterUnityClass<EditorExtension>("Core");
	//21. GameManager
	RegisterUnityClass<GameManager>("Core");
	//22. GameObject
	RegisterUnityClass<GameObject>("Core");
	//23. GlobalGameManager
	RegisterUnityClass<GlobalGameManager>("Core");
	//24. GraphicsSettings
	RegisterUnityClass<GraphicsSettings>("Core");
	//25. InputManager
	RegisterUnityClass<InputManager>("Core");
	//26. LODGroup
	RegisterUnityClass<LODGroup>("Core");
	//27. LevelGameManager
	RegisterUnityClass<LevelGameManager>("Core");
	//28. Light
	RegisterUnityClass<Light>("Core");
	//29. LightProbeProxyVolume
	RegisterUnityClass<LightProbeProxyVolume>("Core");
	//30. LightProbes
	RegisterUnityClass<LightProbes>("Core");
	//31. LightingSettings
	RegisterUnityClass<LightingSettings>("Core");
	//32. LightmapSettings
	RegisterUnityClass<LightmapSettings>("Core");
	//33. LineRenderer
	RegisterUnityClass<LineRenderer>("Core");
	//34. LowerResBlitTexture
	RegisterUnityClass<LowerResBlitTexture>("Core");
	//35. Material
	RegisterUnityClass<Material>("Core");
	//36. Mesh
	RegisterUnityClass<Mesh>("Core");
	//37. MeshFilter
	RegisterUnityClass<MeshFilter>("Core");
	//38. MeshRenderer
	RegisterUnityClass<MeshRenderer>("Core");
	//39. MonoBehaviour
	RegisterUnityClass<MonoBehaviour>("Core");
	//40. MonoManager
	RegisterUnityClass<MonoManager>("Core");
	//41. MonoScript
	RegisterUnityClass<MonoScript>("Core");
	//42. NamedObject
	RegisterUnityClass<NamedObject>("Core");
	//43. Object
	//Skipping Object
	//44. PlayerSettings
	RegisterUnityClass<PlayerSettings>("Core");
	//45. PreloadData
	RegisterUnityClass<PreloadData>("Core");
	//46. QualitySettings
	RegisterUnityClass<QualitySettings>("Core");
	//47. RayTracingShader
	RegisterUnityClass<RayTracingShader>("Core");
	//48. RectTransform
	RegisterUnityClass<UI::RectTransform>("Core");
	//49. ReflectionProbe
	RegisterUnityClass<ReflectionProbe>("Core");
	//50. RenderSettings
	RegisterUnityClass<RenderSettings>("Core");
	//51. RenderTexture
	RegisterUnityClass<RenderTexture>("Core");
	//52. Renderer
	RegisterUnityClass<Renderer>("Core");
	//53. ResourceManager
	RegisterUnityClass<ResourceManager>("Core");
	//54. RuntimeInitializeOnLoadManager
	RegisterUnityClass<RuntimeInitializeOnLoadManager>("Core");
	//55. Shader
	RegisterUnityClass<Shader>("Core");
	//56. ShaderNameRegistry
	RegisterUnityClass<ShaderNameRegistry>("Core");
	//57. Skybox
	RegisterUnityClass<Skybox>("Core");
	//58. SortingGroup
	RegisterUnityClass<SortingGroup>("Core");
	//59. Sprite
	RegisterUnityClass<Sprite>("Core");
	//60. SpriteAtlas
	RegisterUnityClass<SpriteAtlas>("Core");
	//61. SpriteRenderer
	RegisterUnityClass<SpriteRenderer>("Core");
	//62. TagManager
	RegisterUnityClass<TagManager>("Core");
	//63. TextAsset
	RegisterUnityClass<TextAsset>("Core");
	//64. Texture
	RegisterUnityClass<Texture>("Core");
	//65. Texture2D
	RegisterUnityClass<Texture2D>("Core");
	//66. Texture2DArray
	RegisterUnityClass<Texture2DArray>("Core");
	//67. Texture3D
	RegisterUnityClass<Texture3D>("Core");
	//68. TimeManager
	RegisterUnityClass<TimeManager>("Core");
	//69. TrailRenderer
	RegisterUnityClass<TrailRenderer>("Core");
	//70. Transform
	RegisterUnityClass<Transform>("Core");
	//71. GridLayout
	RegisterUnityClass<GridLayout>("Grid");
	//72. Collider
	RegisterUnityClass<Collider>("Physics");
	//73. PhysicsManager
	RegisterUnityClass<PhysicsManager>("Physics");
	//74. Rigidbody
	RegisterUnityClass<Rigidbody>("Physics");
	//75. Collider2D
	RegisterUnityClass<Collider2D>("Physics2D");
	//76. EdgeCollider2D
	RegisterUnityClass<EdgeCollider2D>("Physics2D");
	//77. Physics2DSettings
	RegisterUnityClass<Physics2DSettings>("Physics2D");
	//78. PolygonCollider2D
	RegisterUnityClass<PolygonCollider2D>("Physics2D");
	//79. Rigidbody2D
	RegisterUnityClass<Rigidbody2D>("Physics2D");
	//80. SpriteShapeRenderer
	RegisterUnityClass<SpriteShapeRenderer>("SpriteShape");
	//81. Terrain
	RegisterUnityClass<Terrain>("Terrain");
	//82. TerrainData
	RegisterUnityClass<TerrainData>("Terrain");
	//83. Font
	RegisterUnityClass<TextRendering::Font>("TextRendering");
	//84. Tilemap
	RegisterUnityClass<Tilemap>("Tilemap");
	//85. TilemapRenderer
	RegisterUnityClass<TilemapRenderer>("Tilemap");
	//86. Canvas
	RegisterUnityClass<UI::Canvas>("UI");
	//87. CanvasGroup
	RegisterUnityClass<UI::CanvasGroup>("UI");
	//88. CanvasRenderer
	RegisterUnityClass<UI::CanvasRenderer>("UI");
	//89. UIRenderer
	RegisterUnityClass<UIRenderer>("UIElements");
	//90. VFXManager
	RegisterUnityClass<VFXManager>("VFX");
	//91. VFXRenderer
	RegisterUnityClass<VFXRenderer>("VFX");
	//92. VisualEffect
	RegisterUnityClass<VisualEffect>("VFX");
	//93. VisualEffectAsset
	RegisterUnityClass<VisualEffectAsset>("VFX");
	//94. VisualEffectObject
	RegisterUnityClass<VisualEffectObject>("VFX");

}
