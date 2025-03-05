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

class CountryFnLnBatchExample
{
    fun countryFnLnBatch()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        val personalNames1 = FirstLastNameIn(
            id = "9a3283bd-4efb-4b7b-906c-e3f3c03ea6a4",
            firstName = "Keith",
            lastName = "Haring",
        )

        val personalNames = arrayListOf<FirstLastNameIn>(
            personalNames1,
        )

        val batchFirstLastNameIn = BatchFirstLastNameIn(
            personalNames = personalNames,
        )

        try
        {
            val response = PersonalApi().countryFnLnBatch(
                batchFirstLastNameIn = batchFirstLastNameIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PersonalApi#countryFnLnBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PersonalApi#countryFnLnBatch")
            e.printStackTrace()
        }
    }
}
