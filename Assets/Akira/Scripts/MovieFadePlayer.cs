using UnityEngine;

public class MovieFadePlayer : MonoBehaviour
{
    private MovieFade[] _movies = new MovieFade[3];
    private int _index = 0;

    public int Index { get => _index; set => _index = value; }
    
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _movies[i] = transform.GetChild(i).GetComponent<MovieFade>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!_movies[_index].IsFade)
            {
                _movies[_index].FadeOut();
            }
        }
    }
}
