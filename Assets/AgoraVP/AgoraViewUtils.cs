using UnityEngine;
using UnityEngine.UI;
using Agora_RTC_Plugin.API_Example;

namespace Agora.Rtc.Utils
{
    public class AgoraViewUtils
    {
        internal enum DisplayContainerType
        {
            RawImage,
            Plane,
            CustomMesh
        };

        internal static GameObject MakeVideoView(uint uid, string channelId, DisplayContainerType displayType, GameObject prefab = null)
        {
            var go = GameObject.Find(uid.ToString());
            if (!ReferenceEquals(go, null))
            {
                return go; // reuse
            }

            // create a GameObject and assign to this new user
            VideoSurface videoSurface = null;

            switch (displayType)
            {
                case DisplayContainerType.RawImage:
                    videoSurface = MakeImageSurface(uid.ToString());
                    break;
                case DisplayContainerType.Plane:
                    videoSurface = MakePlaneSurface(uid.ToString());
                    break;
                case DisplayContainerType.CustomMesh:
                    if (prefab != null)
                    {
                        videoSurface = MakeCustomMesh(uid.ToString(), prefab);
                    }
                    else
                    {
                        Debug.LogError("Prefab is NULL!");
                        return null;
                    }
                    break;
            }

            if (videoSurface == null) return null;

            // configure videoSurface
            if (uid == 0)
            {
                videoSurface.SetForUser(uid, channelId);
            }
            else
            {
                videoSurface.SetForUser(uid, channelId, VIDEO_SOURCE_TYPE.VIDEO_SOURCE_REMOTE);
            }

            videoSurface.OnTextureSizeModify += (int width, int height) =>
            {
                float scale = (float)height / (float)width;
                videoSurface.transform.localScale = new Vector3(-5, 1, 5 * scale);
                Debug.Log("OnTextureSizeModify: " + width + "  " + height);
            };

            videoSurface.SetEnable(true);
            videoSurface.gameObject.name = "videosurface_" + uid;
            return videoSurface.gameObject;
        }

        private static VideoSurface MakeCustomMesh(string goName, GameObject prefab)
        {
            var go = GameObject.Instantiate(prefab);
            // configure videoSurface
            var videoSurface = go.AddComponent<VideoSurface>();
            go.transform.Rotate(-90.0f, 0.0f, 0.0f);
            return videoSurface;
        }
        // put a video surface on Plane
        private static VideoSurface MakePlaneSurface(string goName)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Plane);

            if (go == null)
            {
                return null;
            }

            go.name = goName;
            var mesh = go.GetComponent<MeshRenderer>();
            if (mesh != null)
            {
                Debug.LogWarning("VideoSureface update shader");
                mesh.material = new Material(Shader.Find("Unlit/Texture"));
            }
            // set up transform
            go.transform.Rotate(-90.0f, 0.0f, 0.0f);

            // configure videoSurface
            var videoSurface = go.AddComponent<VideoSurface>();
            return videoSurface;
        }

        // put a video surface on RawImage
        private static VideoSurface MakeImageSurface(string goName)
        {
            GameObject go = new GameObject();

            if (go == null)
            {
                return null;
            }

            go.name = goName;
            // to be renderered onto
            go.AddComponent<RawImage>();
            // make the object draggable
            go.AddComponent<UIElementDrag>();
            var canvas = GameObject.Find("VideoCanvas");
            if (canvas != null)
            {
                go.transform.parent = canvas.transform;
                Debug.Log("add video view");
            }
            else
            {
                Debug.Log("Canvas is null video view");
            }

            // set up transform
            go.transform.Rotate(0f, 0.0f, 180.0f);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = new Vector3(2f, 3f, 1f);

            // configure videoSurface
            var videoSurface = go.AddComponent<VideoSurface>();
            return videoSurface;
        }

        internal static void DestroyVideoView(uint uid)
        {
            var go = GameObject.Find("videosurface_" + uid.ToString());
            if (!ReferenceEquals(go, null))
            {
                GameObject.Destroy(go);
            }
        }


    }
}
