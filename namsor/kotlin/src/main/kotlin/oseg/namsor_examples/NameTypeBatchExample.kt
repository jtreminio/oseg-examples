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
class NameTypeBatchExample
{
    fun nameTypeBatch()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        val properNouns1 = NameIn(
            id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            name = "Zippo",
        )

        val properNouns = arrayListOf<NameIn>(
            properNouns1,
        )

        val batchNameIn = BatchNameIn(
            properNouns = properNouns,
        )

        try
        {
            val response = GeneralApi().nameTypeBatch(
                batchNameIn = batchNameIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling GeneralApi#nameTypeBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling GeneralApi#nameTypeBatch")
            e.printStackTrace()
        }
    }
}
