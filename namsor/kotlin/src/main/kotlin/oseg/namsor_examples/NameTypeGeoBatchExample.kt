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
class NameTypeGeoBatchExample
{
    fun nameTypeGeoBatch()
    {
        ApiClient.apiKey["X-API-KEY"] = "YOUR_API_KEY"

        val properNouns1 = NameGeoIn(
            id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            name = "Edi Gathegi",
            countryIso2 = "KE",
        )

        val properNouns = arrayListOf<NameGeoIn>(
            properNouns1,
        )

        val batchNameGeoIn = BatchNameGeoIn(
            properNouns = properNouns,
        )

        try
        {
            val response = GeneralApi().nameTypeGeoBatch(
                batchNameGeoIn = batchNameGeoIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling GeneralApi#nameTypeGeoBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling GeneralApi#nameTypeGeoBatch")
            e.printStackTrace()
        }
    }
}
