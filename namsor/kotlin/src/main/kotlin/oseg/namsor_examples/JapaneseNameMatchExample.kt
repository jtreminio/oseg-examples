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

class JapaneseNameMatchExample
{
    fun japaneseNameMatch()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        try
        {
            val response = JapaneseApi().japaneseNameMatch(
                japaneseSurnameLatin = "Tessai",
                japaneseGivenNameLatin = "Tomioka",
                japaneseName = "富岡 鉄斎",
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling JapaneseApi#japaneseNameMatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling JapaneseApi#japaneseNameMatch")
            e.printStackTrace()
        }
    }
}
