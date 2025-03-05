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
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class ChineseNameMatchExample
{
    fun chineseNameMatch()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        try
        {
            val response = ChineseApi().chineseNameMatch(
                chineseSurnameLatin = "Yu",
                chineseGivenNameLatin = "Hong",
                chineseName = "喻红",
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ChineseApi#chineseNameMatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ChineseApi#chineseNameMatch")
            e.printStackTrace()
        }
    }
}
