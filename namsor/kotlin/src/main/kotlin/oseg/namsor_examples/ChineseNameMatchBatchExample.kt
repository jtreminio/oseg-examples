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
class ChineseNameMatchBatchExample
{
    fun chineseNameMatchBatch()
    {
        ApiClient.apiKey["X-API-KEY"] = "YOUR_API_KEY"

        val personalNames1Name1 = FirstLastNameIn(
            id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            firstName = "Hong",
            lastName = "Yu",
        )

        val personalNames1Name2 = PersonalNameIn(
            id = "e630dda5-13b3-42c5-8f1d-648aa8a21c43",
            name = "喻红",
        )

        val personalNames1 = MatchPersonalFirstLastNameIn(
            id = "e630dda5-13b3-42c5-8f1d-648aa8a21c41",
            name1 = personalNames1Name1,
            name2 = personalNames1Name2,
        )

        val personalNames = arrayListOf<MatchPersonalFirstLastNameIn>(
            personalNames1,
        )

        val batchMatchPersonalFirstLastNameIn = BatchMatchPersonalFirstLastNameIn(
            personalNames = personalNames,
        )

        try
        {
            val response = ChineseApi().chineseNameMatchBatch(
                batchMatchPersonalFirstLastNameIn = batchMatchPersonalFirstLastNameIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ChineseApi#chineseNameMatchBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ChineseApi#chineseNameMatchBatch")
            e.printStackTrace()
        }
    }
}
