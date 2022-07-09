using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    private void Start() => SetResolution(); // 초기에 게임 해상도 고정
    void OnPreCull() => GL.Clear(true, true, Color.black); //해상도 수정 부분 검은색으로 칠해주기
                                                           //없으면 잔상이 남음, OnPreCull은 씬로딩 단계에 실행되는 함수

    /* 해상도 설정하는 함수 */
    public void SetResolution()
    {
        int setWidth = 1440; // 고정 너비
        int setHeight = 2960; // 고정 높이

        int deviceWidth = Screen.width; // 기기 너비
        int deviceHeight = Screen.height; // 기기 높이

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution 함수 제대로 사용하기

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // 새로운 너비
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // 새로운 높이
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
        }
    }
}
