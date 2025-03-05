package oseg.namsor_examples

import app.namsor.client.infrastructure.*
import app.namsor.client.apis.*
import app.namsor.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map

class ParseJapaneseNameExample
{
    fun parseJapaneseName()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        try
        {
            val response = JapaneseApi().parseJapaneseName(
                japaneseName = "小島 秀夫",
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling JapaneseApi#parseJapaneseName")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling JapaneseApi#parseJapaneseName")
            e.printStackTrace()
        }
    }
}
