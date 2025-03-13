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
class DiasporaBatchExample
{
    fun diasporaBatch()
    {
        ApiClient.apiKey["X-API-KEY"] = "YOUR_API_KEY"

        val personalNames1 = FirstLastNameGeoIn(
            id = "0d7d6417-0bbb-4205-951d-b3473f605b56",
            firstName = "Keith",
            lastName = "Haring",
            countryIso2 = "US",
        )

        val personalNames = arrayListOf<FirstLastNameGeoIn>(
            personalNames1,
        )

        val batchFirstLastNameGeoIn = BatchFirstLastNameGeoIn(
            personalNames = personalNames,
        )

        try
        {
            val response = PersonalApi().diasporaBatch(
                batchFirstLastNameGeoIn = batchFirstLastNameGeoIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PersonalApi#diasporaBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PersonalApi#diasporaBatch")
            e.printStackTrace()
        }
    }
}
